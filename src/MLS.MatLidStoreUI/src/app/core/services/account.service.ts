/*
 * Project: MatLidStore (https://github.com/phamtiendungcw/matlidstore)
 * File: account.service.ts
 * Author: phamtiendungcw (https://github.com/phamtiendungcw)
 * Contact: Pham Tien Dung (phamtiendungcw@gmail.com)
 * Last Modified: Thứ Bảy, 09-11-2024 | 02:57 SA
 * --------
 * Copyright © 2023 - 2024 Pham Tien Dung, MatLidStore Ltd. All rights reserved.
 * --------
 * Description:
 *   This file is part of the MLS.MatLidStoreUI project.
 *   Unauthorized copying or distribution of this file, via any medium, is strictly prohibited.
 * --------
 * License: Proprietary and confidential.
 */

import { Injectable } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { BehaviorSubject } from 'rxjs';

import { AuthResponse } from '../data/mls-data.service';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  // Người dùng hiện tại BehaviorSubject để lưu trữ chi tiết người dùng
  private readonly currentUserSubject = new BehaviorSubject<AuthResponse | null>(null);
  currentUser$ = this.currentUserSubject.asObservable();

  constructor() {
    // Kiểm tra xem có mã thông báo trong localStorage khi dịch vụ được khởi chạy không
    const storedUser = localStorage.getItem('usr');
    if (storedUser) {
      const parsedUser = JSON.parse(storedUser);
      this.currentUserSubject.next(parsedUser);
    }
  }

  // Hàm để set current user
  setCurrentUser(user: AuthResponse): void {
    localStorage.setItem('usr', JSON.stringify(user));
    this.currentUserSubject.next(user);
  }

  // Hàm để remove current user (đăng xuất)
  removeCurrentUser(): void {
    localStorage.removeItem('usr');
    this.currentUserSubject.next(null);
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
