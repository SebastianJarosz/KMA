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
  creationTime?: Date;
  modificationTime?: Date;
  status?: string;
  orderPostionList?: Array<OrderPostion>;
  statusColor?: string;
  constructor() { }

  @Input() order?: Order;
  ngOnInit(): void {
    
    this.orderNumber = this.order?.orderNumber;
    this.status = this.order?.status;
    this.orderPostionList = this.order?.orderPostion;
    if(this.status == "InProgress"){
      this.statusColor = "#fdff8b"; 
    }
    else if(this.status == "Ready"){
      this.statusColor = "#8bffa4";
    }
    else{
      this.statusColor = "#696868";
    }
  }
  onSubmit(){

  }

}
