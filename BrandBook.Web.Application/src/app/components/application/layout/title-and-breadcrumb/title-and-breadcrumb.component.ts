import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';


@Component({
  selector: 'app-layout-title-and-breadcrumb',
  templateUrl: './title-and-breadcrumb.component.html',
  styleUrls: ['./title-and-breadcrumb.component.scss']
})

export class LayoutTitleAndBreadcrumbComponent implements OnInit {

  pageTitle: string;

  constructor(private titleService: Title) { }

  ngOnInit(): void {
    this.pageTitle = this.titleService.getTitle();
  }

}
