import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadyTicketComponent } from './ready-ticket.component';

describe('ReadyTicketComponent', () => {
  let component: ReadyTicketComponent;
  let fixture: ComponentFixture<ReadyTicketComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReadyTicketComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReadyTicketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
