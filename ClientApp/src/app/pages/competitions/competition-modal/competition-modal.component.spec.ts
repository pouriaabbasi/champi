import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionModalComponent } from './competition-modal.component';

describe('CompetitionModalComponent', () => {
  let component: CompetitionModalComponent;
  let fixture: ComponentFixture<CompetitionModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
