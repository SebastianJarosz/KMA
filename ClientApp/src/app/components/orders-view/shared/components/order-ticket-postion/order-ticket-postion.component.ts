import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UrlSettings } from 'src/app/shared/models/url-settings.model';
import { Order, OrderPostion } from '../../models/order.model';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-order-ticket-postion',
  templateUrl: './order-ticket-postion.component.html',
  styleUrls: ['./order-ticket-postion.component.css']
})
export class OrderTicketPostionComponent implements OnInit {

  menuPostionName?: string;
  menuPostionCode?: string;
  quantityOfMenuPostion?: number;
  isReady?: boolean;
  orderPostionPresentation?: string;
  order?: Order | any;
  isNotEmpty?: boolean;
  error?: string;
  updateOrderPostion?: OrderPostion | any;

  constructor(private orderService: OrderService,
      private url: UrlSettings,
      private router: Router) { }
  
  @Input() orderPostion?: OrderPostion;
  @Input() postionNumber?: number | any;
  @Input() orderGuid?: string | any;
  ngOnInit(): void {
    this.menuPostionName = this.orderPostion?.menuPostionName;
    this.menuPostionCode = this.orderPostion?.menuPostionCode;
    this.quantityOfMenuPostion = this.orderPostion?.quantityOfMenuPostion;
    this.isReady = this.orderPostion?.isReady;
    if(this.isReady){
      this.orderPostionPresentation = "line-through";
    } else{
      this.orderPostionPresentation = "none";
    }
    this.getOreder();
  }
  onSubmit(): void{

  }
  getOreder(): void{
    this.orderService
    .get(`${this.url?.baseUrl}OrdersMenagment/v1/Order/${this.orderGuid}`)
    .subscribe(responseData  => {
      this.order = responseData; 
      this.isNotEmpty = (this.order != null) ? true : false;
      },
      error => {
          if(error.status == 404){
            this.error = 'Błędny aders';
            console.error('Błędny aders');
          }else if(error.status == 500){
            this.error = 'Błąd połączenia z serwerem';
            console.error('Błąd połaczeniaz serwerem');
          }
        }
      );
  }
  updateOrderPostionStatus(): void{
    console.log(this.order?.orderPostion[this.postionNumber]);
    this.updateOrderPostion = this.order?.orderPostion[this.postionNumber];
    this.updateOrderPostion.isReady = !this.isReady;
    let updateOrder = this.order; 
    updateOrder.orderPostion[this.postionNumber] = this.updateOrderPostion; 
    this.orderService
            .patch(`${this.url?.baseUrl}OrdersMenagment/v1/EditOrder/${this.orderGuid}`, updateOrder)
            .subscribe(responseData => {
              let flag = true;
              console.log(responseData);
              responseData.body?.orderPostion?.forEach(element => {
                if(element.isReady == false){
                  flag = false;
                }
              });
              console.log(flag);
              if(flag){
                this.orderService
                .putSetOrderStatus(`${this.url?.baseUrl}OrdersMenagment/v1/ChangeOrderStatusOnReady/${this.orderGuid}`)
                .subscribe(responseData => {
                  console.log(responseData);
                  });
              }
            });
  }
}
