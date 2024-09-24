import { Component } from '@angular/core';
import { EntityService } from 'src/app/core/services/entity.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
})
export class TableComponent {
  entityList: any[] = [];

  constructor(private entityService: EntityService) {}

  // ngOnInit(): void {
  //   this.loadEntities('employees'); // Ví dụ: load data cho Employees entity
  // }

  loadEntities(entity: string): void {
    this.entityService.getEntities(entity).subscribe((data: any) => {
      this.entityList = data;
    });
  }
}
