import { Component, OnInit, ViewChild } from '@angular/core';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexTitleSubtitle
} from "ng-apexcharts";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-dashboard-recent-activity-chart',
  templateUrl: './recent-activity-chart.component.html',
  styleUrls: ['./recent-activity-chart.component.scss']
})
export class RecentActivityChartComponent implements OnInit {

  @ViewChild("chart") chart: ChartComponent;
  public chartOptions;

  constructor() {
    this.chartOptions = {
      series: [
        {
          name: "Recent Activity",
          data: [10, 41, 35, 51, 49, 62, 69, 91, 148]
        }
      ],
      chart: {
        height: 350,
        type: "area"
      },
      title: {
        text: "Recent Brand-Activity Chart"
      },
      xaxis: {
        categories: ["Jan", "Feb",  "Mar",  "Apr",  "May",  "Jun",  "Jul",  "Aug", "Sep"]
      }
    };
  }

  ngOnInit(): void { }

}
