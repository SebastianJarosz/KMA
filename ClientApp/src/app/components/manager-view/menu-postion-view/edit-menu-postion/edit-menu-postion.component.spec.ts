import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMenuPostionComponent } from './edit-menu-postion.component';

describe('EditMenuPostionComponent', () => {
  let component: EditMenuPostionComponent;
  let fixture: ComponentFixture<EditMenuPostionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditMenuPostionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditMenuPostionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
