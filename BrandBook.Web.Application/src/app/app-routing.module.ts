import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';


const routes: Routes = [
    { path: '', component: DashboardComponent },
    { path: 'v2', component: DashboardComponent },
    { path: 'Dashboard', component: DashboardComponent },

    { path: 'User/Profile', component: DashboardComponent },
    { path: 'User/Settings', component: DashboardComponent },
    { path: 'User/Subscriptions', component: DashboardComponent },

  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
