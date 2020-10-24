import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';


const routes: Routes = [
    { path: '', component: DashboardComponent, pathMatch: 'full' },
    { path: 'v2', component: DashboardComponent, pathMatch: 'full' },
    { path: 'Dashboard/RedesignEntry', component: DashboardComponent, pathMatch: 'full' }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
