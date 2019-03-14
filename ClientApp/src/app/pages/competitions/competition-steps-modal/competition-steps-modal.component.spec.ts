import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionStepsModalComponent } from './competition-steps-modal.component';

describe('CompetitionStepsModalComponent', () => {
  let component: CompetitionStepsModalComponent;
  let fixture: ComponentFixture<CompetitionStepsModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionStepsModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionStepsModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
