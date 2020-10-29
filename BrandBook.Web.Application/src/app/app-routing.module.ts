import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthLayoutComponent } from './components/authentication/auth-layout.component';
import { AppLayoutComponent } from './components/application/app-layout.component';

import { AuthLoginComponent } from './components/authentication/login/auth-login.component';
import { AuthRegisterComponent } from './components/authentication/register/auth-register.component';
import { AuthForgotPasswordComponent } from './components/authentication/forgotPassword/auth-forgot-password.component';

import { DashboardComponent } from './components/application/dashboard/dashboard.component';
import { UserProfileComponent } from './components/application/user/profile/user-profile.component';
import { UserSettingsComponent } from './components/application/user/settings/user-settings.component';
import { UserSubscriptionsComponent } from './components/application/user/subscriptions/user-subscriptions.component';
import { BrandsOverviewComponent } from './components/application/brands/overview/brands-overview.component';



const routes: Routes = [

    {
      path: 'App',
      component: AppLayoutComponent,
      children: [
        { path: '', redirectTo: 'Dashboard', pathMatch: 'full' },
        { path: 'Dashboard', component: DashboardComponent, data: { title: 'Dashboard' } },
        { path: 'Brands/Overview', component: BrandsOverviewComponent, data: { title: 'Brands Overview' } },
        { path: 'User/Profile', component: UserProfileComponent, data: { title: 'My Profile' } },
        { path: 'User/Settings', component: UserSettingsComponent, data: { title: 'My Settings' } },
        { path: 'User/Subscriptions', component: UserSubscriptionsComponent, data: { title: 'My Subscriptions' } }
      ]
   },

    {
      path: 'Auth',
      component: AuthLayoutComponent,
      children: [
        { path: '', redirectTo: 'Login', pathMatch: 'full' },
        { path: 'Login', component: AuthLoginComponent, data: { title: 'Login' } },
        { path: 'Register', component: AuthRegisterComponent, data: { title: 'Register' } },
        { path: 'ForgotPassword', component: AuthForgotPasswordComponent, data: { title: 'Forgot Password' } }
      ]
    },

    { path: '**', redirectTo: 'App' }

  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
