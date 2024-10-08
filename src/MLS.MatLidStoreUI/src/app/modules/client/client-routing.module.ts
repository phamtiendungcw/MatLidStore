import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ClientHomeComponent } from './client-home/client-home.component';

const routes: Routes = [
  {
    path: '',
    component: ClientHomeComponent,
    children: [
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: '', loadChildren: () => import('../../theme/pages/pages.module').then((m) => m.PagesModule) },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientRoutingModule {}
