import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SiginViewComponent } from './sigin-view.component';

describe('SiginViewComponent', () => {
  let component: SiginViewComponent;
  let fixture: ComponentFixture<SiginViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SiginViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SiginViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
