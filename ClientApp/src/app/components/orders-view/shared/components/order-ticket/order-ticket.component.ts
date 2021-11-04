import { Time } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { map } from 'rxjs/operators';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { Order, OrderPostion } from '../../models/order.model';
import { OrderService } from '../../services/order.service';

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

  constructor(private orderService: OrderService,
    private url: UrlSettings,) { }

  @Input() order?: Order;
  @Input() orderIndex?: number;
  ngOnInit(): void {
    
    this.orderNumber = this.order?.orderNumber;
    this.status = this.order?.status;
    this.orderPostionList = this.order?.orderPostion;
    this.orderGuid = this.order?.orderGuid;

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
  closeOrder(){
    this.orderService
      .putSetOrderStatus(`${this.url?.baseUrl}OrdersMenagment/v1/ChangeOrderStatusOnClosed/${this.orderGuid}`)
      .subscribe(responseData => {
        console.log(responseData);
        });
  }

}
