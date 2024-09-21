import { Injectable } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { BehaviorSubject } from 'rxjs';
import { AuthResponse } from '../data/mls-data.service';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private loggedInSubject = new BehaviorSubject<boolean>(false);
  loggerIn$ = this.loggedInSubject.asObservable();

  // Current user BehaviorSubject to store user details
  private currentUserSubject = new BehaviorSubject<AuthResponse | null>(null);
  currentUser$ = this.currentUserSubject.asObservable();

  constructor() {
    // Check if there's a token in localStorage when service is initialized
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      const parsedUser = JSON.parse(storedUser);
      this.currentUserSubject.next(parsedUser);
      this.setLoggedIn(true);
    }
  }

  // Hàm để thay đổi trạng thái đăng nhập
  setLoggedIn(isLoggedIn: boolean): void {
    this.loggedInSubject.next(isLoggedIn);
  }

  // Hàm để lấy trạng thái đăng nhập
  isLoggedIn(): boolean {
    return this.loggedInSubject.value;
  }

  // Hàm để set current user
  setCurrentUser(user: AuthResponse): void {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSubject.next(user);
    this.setLoggedIn(true);
  }

  // Hàm để remove current user (đăng xuất)
  removeCurrentUser(): void {
    localStorage.removeItem('user');
    this.currentUserSubject.next(null);
    this.setLoggedIn(false);
  }

  // Hàm để lấy current user
  getCurrentUser(): AuthResponse | null {
    return this.currentUserSubject.value;
  }

  // Hàm để lấy token từ user
  getToken(): string | null {
    return this.currentUserSubject.value?.token ?? null;
  }

  // Hàm để kiểm tra token đã hết hạn hay chưa
  isTokenExpired(token: string): boolean {
    try {
      const decoded: { exp: number } = jwtDecode(token);
      const currentTime = Math.floor(Date.now() / 1000);
      return decoded.exp < currentTime;
    } catch (error) {
      return true; // Nếu có lỗi khi giải mã token, coi như đã hết hạn
    }
  }
}
