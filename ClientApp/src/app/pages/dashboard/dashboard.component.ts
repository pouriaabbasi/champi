import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { StatisticsModel } from 'src/app/models/dashboard/statistics.model';
import { DashboardService } from 'src/app/Services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  statistics: StatisticsModel = new StatisticsModel();
  chartLine = [];
  chartBar = [];
  chartHbar = [];

  options = {
    scales: {
      yAxes: [{
        ticks: {
          fontColor: 'rgba(0,0,0,.6)',
          fontStyle: 'bold',
          beginAtZero: true,
          maxTicksLimit: 8,
          padding: 10
        },
        gridLines: {
          drawTicks: true,
          drawBorder: true,
          display: true,
          color: 'rgba(0,0,0,.1)',
          // zeroLineColor: 'transparent'
        }

      }],
      xAxes: [{
        gridLines: {
          // zeroLineColor: 'transparent',
          display: true,

        },
        ticks: {
          padding: 0,
          fontColor: 'rgba(0,0,0,0.6)',
          fontStyle: 'bold'
        }
      }]
    },
    responsive: true
  };

  constructor(
    private dashboardService: DashboardService
  ) { }

  ngOnInit() {
    this.fetchData();
  }

  private fetchData() {
    this.dashboardService.getStatistics()
      .subscribe(statistics => {
        this.statistics = statistics;

        this.chartLine = new Chart('league-per-month', {
          type: 'line',
          data: this.statistics.leaguePerMonthData,
          options: this.options
        });

        this.chartBar = new Chart('league-by-league-type-total', {
          type: 'bar',
          data: this.statistics.leagueByLeagueTypeData,
          options: this.options
        });
      });
  }
}
