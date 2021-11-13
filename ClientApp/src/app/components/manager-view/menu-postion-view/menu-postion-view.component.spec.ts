import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuPostionViewComponent } from './menu-postion-view.component';

describe('MenuPostionViewComponent', () => {
  let component: MenuPostionViewComponent;
  let fixture: ComponentFixture<MenuPostionViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuPostionViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuPostionViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
