import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientHomeComponent } from './client-home/client-home.component';
import { WelcomeComponent } from 'src/app/theme/pages/welcome/welcome.component';

const routes: Routes = [
  {
    path: '',
    component: ClientHomeComponent,
    children: [
      {
        path: 'login',
        loadChildren: () => import('src/app/theme/pages/account/account.module').then(m => m.AccountModule),
      },
      {
        path: 'welcome',
        component: WelcomeComponent,
        loadChildren: () => import('src/app/theme/pages/pages.module').then(m => m.PagesModule),
      },
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
})
export class AppClientRoutingModule {}
