import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../services/account.service';

export const authGuard: CanActivateFn = () => {
  const accountService = inject(AccountService);
  const toastr = inject(ToastrService);
  const router = inject(Router);

  if (accountService.getCurrentUser()) {
    return true;
  } else {
    router.navigate(['/account/login']);
    toastr.error('Bạn cần đăng nhập để có quyền truy cập trang này!');
    return false;
  }
};
