import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BrandsOverviewComponent } from './components/brands/overview/brands-overview.component';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserProfileComponent } from './components/user/profile/user-profile.component';


const routes: Routes = [
    { path: '', component: DashboardComponent },
    { path: 'v2', component: DashboardComponent },
    { path: 'Dashboard', component: DashboardComponent },

    { path: 'Brands/Overview', component: BrandsOverviewComponent },

    { path: 'User/Profile', component: UserProfileComponent },
    { path: 'User/Settings', component: DashboardComponent },
    { path: 'User/Subscriptions', component: DashboardComponent },

  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
