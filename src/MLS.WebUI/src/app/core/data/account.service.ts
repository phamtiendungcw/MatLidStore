import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private loggerInSubject = new BehaviorSubject<boolean>(false);
  loggerIn$ = this.loggerInSubject.asObservable();

  setLoggedIn(value: boolean) {
    this.loggerInSubject.next(value);
  }
}
