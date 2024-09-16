import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private loggedInSubject = new BehaviorSubject<boolean>(false);
  loggerIn$ = this.loggedInSubject.asObservable();

  // Hàm để thay đổi trạng thái đăng nhập
  setLoggedIn(isLoggedIn: boolean): void {
    this.loggedInSubject.next(isLoggedIn);
  }

  // Hàm để lấy trạng thái đăng nhập
  isLoggedIn(): boolean {
    return this.loggedInSubject.value;
  }
}
