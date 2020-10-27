import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthLayoutComponent } from './components/authentication/auth-layout.component';
import { AppLayoutComponent } from './components/application/app-layout.component';

import { AuthLoginComponent } from './components/authentication/login/auth-login.component';
import { BrandsOverviewComponent } from './components/application/brands/overview/brands-overview.component';

import { DashboardComponent } from './components/application/dashboard/dashboard.component';
import { UserProfileComponent } from './components/application/user/profile/user-profile.component';
import { UserSettingsComponent } from './components/application/user/settings/user-settings.component';
import { UserSubscriptionsComponent } from './components/application/user/subscriptions/user-subscriptions.component';


const routes: Routes = [

    { path: '', component: AppLayoutComponent, children: [
      { path: 'v2', component: DashboardComponent },
      { path: 'Dashboard', component: DashboardComponent },

      { path: 'Brands/Overview', component: BrandsOverviewComponent },

      { path: 'User/Profile', component: UserProfileComponent },
      { path: 'User/Settings', component: UserSettingsComponent },
      { path: 'User/Subscriptions', component: UserSubscriptionsComponent }
    ] },


    { path: '', component: AuthLayoutComponent, children: [
      { path: 'Login', component: AuthLoginComponent }
    ] }

  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
