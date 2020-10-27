import { Component, OnInit, ViewChild } from '@angular/core';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexTitleSubtitle,
  NgApexchartsModule,
  ApexFill
} from 'ng-apexcharts';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  title: ApexTitleSubtitle;
  fill: ApexFill;
};

@Component({
  selector: 'app-dashboard-recent-activity-chart',
  templateUrl: './recent-activity-chart.component.html',
  styleUrls: ['./recent-activity-chart.component.scss']
})
export class RecentActivityChartComponent implements OnInit {

  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  constructor() {

    this.initChart();

  }

  ngOnInit(): void { }

  public initChart(): void {
    this.chartOptions = {
      series: [
        {
          name: 'Recent Activity',
          data: [45, 52, 38, 24, 33, 26, 21, 20, 60, 80, 150, 100, 110, 41, 35, 51, 49, 62, 69, 91, 148]
        }
      ],
      chart: {
        type: 'area',
        height: 200,
        sparkline: {
            enabled: true
        },
      },
      fill: {
          opacity: 0.2,
          colors: ['#6559cc']
      },
      xaxis: {
        categories: ['Jul',  'Aug', 'Sep', 'Oct']
      }
    };
  }

}
