import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { EntityService } from 'src/app/core/services/entity.service';

interface Entity {
  id: number; // Mọi thực thể cần có thuộc tính id
  [key: string]: unknown; // Cho phép truy cập các thuộc tính động
}

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
})
export class TableComponent<T extends Entity> implements OnInit {
  @Input() entityName = '';
  @Input() columns: string[] = [];
  data: T[] = [];

  constructor(
    private entityService: EntityService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.fetchData();
  }

  fetchData(): void {
    const getAllMethod = this.getAllMethod();
    if (getAllMethod) {
      getAllMethod().subscribe({
        next: (response: T[]) => {
          this.data = response;
        },
        error: err => {
          console.error('Error fetching data: ', err);
        },
      });
    } else {
      console.error(`Entity ${this.entityName} không được hỗ trợ.`);
    }
  }

  editEntity(id: number): void {
    this.router.navigate([`/${this.entityName.toLowerCase()}/edit`, id]);
  }

  deleteEntity(id: number): void {
    if (confirm('Bạn có chắc chắn muốn xóa mục này?')) {
      const deleteMethod = this.getDeleteMethod();
      if (deleteMethod) {
        deleteMethod(id).subscribe({
          next: () => {
            this.fetchData(); // Refresh table after deletion
          },
          error: err => {
            console.error('Error deleting entity: ', err);
          },
        });
      }
    }
  }

  viewEntity(id: number): void {
    this.router.navigate([`/${this.entityName.toLowerCase()}/view`, id]);
  }

  private getAllMethod(): (() => Observable<T[]>) | undefined {
    switch (this.entityName) {
      case 'Address':
        return () => this.entityService.getAllAddresses() as unknown as Observable<T[]>; // Ép kiểu
      case 'AppUser':
        return () => this.entityService.getAllAppUsers() as unknown as Observable<T[]>; // Ép kiểu
      // Thêm các trường hợp cho các thực thể khác
      default:
        return undefined;
    }
  }

  private getDeleteMethod(): ((id: number) => Observable<void>) | undefined {
    switch (this.entityName) {
      case 'Address':
        return (id: number) => this.entityService.deleteAddress(id);
      case 'AppUser':
        return (id: number) => this.entityService.deleteAppUser(id);
      // Thêm các trường hợp cho các thực thể khác
      default:
        return undefined;
    }
  }
}
