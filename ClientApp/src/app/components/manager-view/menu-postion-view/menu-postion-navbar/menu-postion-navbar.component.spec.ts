import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuPostionNavbarComponent } from './menu-postion-navbar.component';

describe('MenuPostionNavbarComponent', () => {
  let component: MenuPostionNavbarComponent;
  let fixture: ComponentFixture<MenuPostionNavbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuPostionNavbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuPostionNavbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
