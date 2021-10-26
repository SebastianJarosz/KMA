import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderTicketPostionComponent } from './order-ticket-postion.component';

describe('OrderTicketPostionComponent', () => {
  let component: OrderTicketPostionComponent;
  let fixture: ComponentFixture<OrderTicketPostionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderTicketPostionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderTicketPostionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
