import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifCoursComponent } from './modif-cours.component';

describe('ModifFriandiseComponent', () => {
  let component: ModifCoursComponent;
  let fixture: ComponentFixture<ModifCoursComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModifCoursComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModifCoursComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
