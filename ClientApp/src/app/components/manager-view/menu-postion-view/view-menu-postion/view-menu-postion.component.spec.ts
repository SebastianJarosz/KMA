import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewMenuPostionComponent } from './view-menu-postion.component';

describe('ViewMenuPostionComponent', () => {
  let component: ViewMenuPostionComponent;
  let fixture: ComponentFixture<ViewMenuPostionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewMenuPostionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewMenuPostionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
