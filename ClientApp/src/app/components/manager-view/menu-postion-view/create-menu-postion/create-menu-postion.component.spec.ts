import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateMenuPostionComponent } from './create-menu-postion.component';

describe('CreateMenuPostionComponent', () => {
  let component: CreateMenuPostionComponent;
  let fixture: ComponentFixture<CreateMenuPostionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateMenuPostionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateMenuPostionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
