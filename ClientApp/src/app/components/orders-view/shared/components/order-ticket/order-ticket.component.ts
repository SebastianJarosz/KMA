import { Time } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { map } from 'rxjs/operators';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { Color } from 'src/app/shared/models/color.model';
import { Order, OrderPostion } from '../../models/order.model';
import { OrderService } from '../../services/order.service';
import { MessageText } from 'src/app/shared/models/messageText.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-ticket',
  templateUrl: './order-ticket.component.html',
  styleUrls: ['./order-ticket.component.css']
})
export class OrderTicketComponent implements OnInit {

  orderGuid?: string;
  orderNumber?: number;
  modificationTime?: Date;
  status?: string;
  orderPostionList?: Array<OrderPostion>;
  statusColor?: string;
  timeInPreparation?: number;
  showTime?: boolean;
  orderPostionStringList?: Array<string>;
  buttonText?: string;

  constructor(private orderService: OrderService,
    private router: Router,
    private url: UrlSettings,
    private color: Color,
    private messageText: MessageText ){ }

  @Input() order?: Order;
  @Input() orderIndex?: number;
  ngOnInit(): void {
    
    this.orderNumber = this.order?.orderNumber;
    this.status = this.order?.status;
    this.orderPostionList = this.order?.orderPostion;
    this.orderGuid = this.order?.orderGuid;

    if(this.status == "InProgress"){
      this.statusColor = this.color.orderYellow; 
      this.showTime = true;
      if(this.showTime){
        this.timeInPreparation = (new Date().getTime() - new Date(this.order?.creationTime).getTime())/60000;
        if(this.timeInPreparation >= 30){
          this.statusColor = this.color.orderRed;
        }
      }
    }
    else if(this.status == "Ready"){
      this.statusColor = this.color.orderGreen;
      this.showTime = false;
      this.buttonText = this.messageText.orderButtonReadyText;
    }
    else{
      this.statusColor = this.color.orderGrey;
      this.showTime = false;
      this.buttonText = this.messageText.orderButtonRevrtText;
    }
  }
  changeOrderStatus(){

    console.log(this.order?.status);
    switch (this.order?.status){
      case "Ready":{
        this.orderService
            .putSetOrderStatus(`${this.url?.baseUrl}OrdersMenagment/v1/ChangeOrderStatusOnClosed/${this.orderGuid}`)
            .subscribe(responseData => {
              console.log(responseData);
              });
        break;
      }
      case "Closed":{
        this.orderService
            .putSetOrderStatus(`${this.url?.baseUrl}OrdersMenagment/v1/ChangeOrderStatusOnReady/${this.orderGuid}`)
            .subscribe(responseData => {
              console.log(responseData);
              this.router.navigate([`/orders-view/active-orders`])
              });
        break; 
      }
      case "Aborted":{
        this.orderService
            .putSetOrderStatus(`${this.url?.baseUrl}OrdersMenagment/v1/ChangeOrderStatusOnActive/${this.orderGuid}`)
            .subscribe(responseData => {
              console.log(responseData);
              this.router.navigate([`/orders-view/active-orders`])
              });
        break; 
      }
      default: { 
        console.log("Unknow status of order!"); 
        break; 
     }
    }
    
  }

}
