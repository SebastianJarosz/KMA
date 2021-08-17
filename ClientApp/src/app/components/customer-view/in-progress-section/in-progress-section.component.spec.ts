import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InProgressSectionComponent } from './in-progress-section.component';

describe('InProgressSectionComponent', () => {
  let component: InProgressSectionComponent;
  let fixture: ComponentFixture<InProgressSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InProgressSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InProgressSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
