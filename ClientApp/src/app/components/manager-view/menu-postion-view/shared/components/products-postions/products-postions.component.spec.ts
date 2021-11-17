import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsPostionsComponent } from './products-postions.component';

describe('ProductsPostionsComponent', () => {
  let component: ProductsPostionsComponent;
  let fixture: ComponentFixture<ProductsPostionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductsPostionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductsPostionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
