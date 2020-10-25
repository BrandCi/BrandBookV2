import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgApexchartsModule } from 'ng-apexcharts';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app.component';
import { LeftSidebarComponent } from './components/layout/left-sidebar/left-sidebar.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { RecentActivityChartComponent } from './components/dashboard/recent-activity-chart/recent-activity-chart.component';

import { BrandsOverviewComponent } from './components/brands/overview/brands-overview.component';
import { UserProfileComponent } from './components/user/profile/user-profile.component';
import { UserSettingsComponent } from './components/user/settings/user-settings.component';
import { UserSubscriptionsComponent } from './components/user/subscriptions/user-subscriptions.component';


@NgModule({
  declarations: [
    AppComponent,
    LeftSidebarComponent,
    DashboardComponent,
    RecentActivityChartComponent,

    BrandsOverviewComponent,

    UserProfileComponent,
    UserSettingsComponent,
    UserSubscriptionsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgApexchartsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
