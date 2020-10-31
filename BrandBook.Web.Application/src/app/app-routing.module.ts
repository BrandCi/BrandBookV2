import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthLayoutComponent } from './components/authentication/auth-layout.component';
import { AppLayoutComponent } from './components/application/app-layout.component';

import { DashboardComponent } from './components/application/dashboard/dashboard.component';
import { UserProfileComponent } from './components/application/user/profile/user-profile.component';
import { UserSettingsComponent } from './components/application/user/settings/user-settings.component';
import { UserSubscriptionsComponent } from './components/application/user/subscriptions/user-subscriptions.component';
import { BrandsOverviewComponent } from './components/application/brands/overview/brands-overview.component';

import { LoginComponent } from './authorization/login/login.component';
import { ApplicationPaths } from './authorization/authorization.constants';
import { LogoutComponent } from './authorization/logout/logout.component';



const routes: Routes = [

    {
      path: 'App',
      component: AppLayoutComponent,
      children: [
        { path: '', redirectTo: 'Dashboard', pathMatch: 'full' },
        { path: 'Dashboard', component: DashboardComponent },
        { path: 'Brands/Overview', component: BrandsOverviewComponent },
        { path: 'User/Profile', component: UserProfileComponent },
        { path: 'User/Settings', component: UserSettingsComponent },
        { path: 'User/Subscriptions', component: UserSubscriptionsComponent }
      ]
    },

    {
      path: '',
      component: AuthLayoutComponent,
      children: [
        { path: '', redirectTo: ApplicationPaths.Login, pathMatch: 'full' },
        { path: ApplicationPaths.Register, component: LoginComponent },
        { path: ApplicationPaths.Profile, component: LoginComponent },
        { path: ApplicationPaths.Login, component: LoginComponent },
        { path: ApplicationPaths.LoginFailed, component: LoginComponent },
        { path: ApplicationPaths.LoginCallback, component: LoginComponent },
        { path: ApplicationPaths.LogOut, component: LogoutComponent },
        { path: ApplicationPaths.LoggedOut, component: LogoutComponent },
        { path: ApplicationPaths.LogOutCallback, component: LogoutComponent }
      ]
    },

    { path: '**', redirectTo: 'App' }

  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
