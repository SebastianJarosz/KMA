import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAllMenuPostionsComponent } from './view-all-menu-postions.component';

describe('ViewAllMenuPostionsComponent', () => {
  let component: ViewAllMenuPostionsComponent;
  let fixture: ComponentFixture<ViewAllMenuPostionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewAllMenuPostionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewAllMenuPostionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
