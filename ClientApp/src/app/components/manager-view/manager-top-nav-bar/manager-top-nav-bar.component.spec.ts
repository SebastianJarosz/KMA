import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerTopNavBarComponent } from './manager-top-nav-bar.component';

describe('ManagerTopNavBarComponent', () => {
  let component: ManagerTopNavBarComponent;
  let fixture: ComponentFixture<ManagerTopNavBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagerTopNavBarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagerTopNavBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
