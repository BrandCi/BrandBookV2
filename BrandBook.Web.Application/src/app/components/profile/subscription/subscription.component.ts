import { Component, OnInit } from '@angular/core';
import { Subscription } from '../../../models/profile/subscription/subscription';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.scss']
})
export class SubscriptionComponent implements OnInit {

  subscriptions: Subscription[] = [];

  constructor() {

    this.subscriptions.push({
      identifier: '6J94NE0X',
      type: 'Evaluation'
    });

    this.subscriptions.push({
      identifier: 'Y9AAWVOD',
      type: 'Agency Annually'
    });

    this.subscriptions.push({
      identifier: '2076EBWL',
      type: 'Professional'
    });

   }

  ngOnInit(): void {
  }

}