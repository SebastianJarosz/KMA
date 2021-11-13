import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteMenuPostionComponent } from './delete-menu-postion.component';

describe('DeleteMenuPostionComponent', () => {
  let component: DeleteMenuPostionComponent;
  let fixture: ComponentFixture<DeleteMenuPostionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteMenuPostionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteMenuPostionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
