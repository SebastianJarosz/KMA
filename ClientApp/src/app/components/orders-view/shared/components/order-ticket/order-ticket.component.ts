import { Time } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { map } from 'rxjs/operators';
import { Order, OrderPostion } from '../../models/order.model';

@Component({
  selector: 'app-order-ticket',
  templateUrl: './order-ticket.component.html',
  styleUrls: ['./order-ticket.component.css']
})
export class OrderTicketComponent implements OnInit {

  orderForm: FormGroup = new FormGroup({});
  orderPostionArray = new FormArray([]);
  orderGuid?: string;
  orderNumber?: number;
  modificationTime?: Date;
  status?: string;
  orderPostionList?: Array<OrderPostion>;
  statusColor?: string;
  timeInPreparation?: number;
  showTime?: boolean;
  orderPostionStringList?: Array<string>;
  objectKeys = Object.keys;
  constructor() { }

  @Input() order?: Order;
  ngOnInit(): void {
    
    this.orderNumber = this.order?.orderNumber;
    this.status = this.order?.status;
    this.orderPostionList = this.order?.orderPostion;
    this.orderPostionStringList = this.CreateOrderPostionString(this.orderPostionList);
    if(this.status == "InProgress"){
      this.statusColor = "#FEBD81"; 
      this.showTime = true;
      if(this.showTime){
        this.timeInPreparation = (new Date().getTime() - new Date(this.order?.creationTime).getTime())/60000;
        if(this.timeInPreparation >= 30){
          this.statusColor = "#ff6347";
        }
      }
    }
    else if(this.status == "Ready"){
      this.statusColor = "#8bffa4";
      this.showTime = false;
    }
    else{
      this.statusColor = "#696868";
      this.showTime = false;
    }
  }
  OnSubmit(){

  }
  CreateOrderPostionString(orderPostionList?: Array<OrderPostion>): Array<string>{
    let array = new Array<string>();
    orderPostionList?.forEach(element => {
      array.push(`${element.menuPostionName} x ${element.quantityOfMenuPostion}`);
    });
    return array;
  }

}
