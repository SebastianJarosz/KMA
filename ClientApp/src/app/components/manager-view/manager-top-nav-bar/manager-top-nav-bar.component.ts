import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription, timer } from 'rxjs';
import { map, share } from 'rxjs/operators';

@Component({
  selector: 'app-manager-top-nav-bar',
  templateUrl: './manager-top-nav-bar.component.html',
  styleUrls: ['./manager-top-nav-bar.component.css']
})
export class ManagerTopNavBarComponent implements OnInit {

  rxTime = new Date();
  intervalId?: any;
  subscription?: Subscription;
  constructor(private router: Router) { }


  ngOnInit() {
    // Using RxJS Timer
    this.subscription = timer(0, 1000)
      .pipe(
        map(() => new Date()),
        share()
      )
      .subscribe(time => {
        this.rxTime = time;
      });
  }

  logOut(){
    localStorage.removeItem('token');
    sessionStorage.removeItem('userData');
    this.router.navigate(["/sign-in-view"]);
  }
  ngOnDestroy() {
    clearInterval(this.intervalId);
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
