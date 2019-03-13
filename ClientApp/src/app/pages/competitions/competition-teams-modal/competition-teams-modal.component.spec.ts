import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionTeamsModalComponent } from './competition-teams-modal.component';

describe('CompetitionTeamsModalComponent', () => {
  let component: CompetitionTeamsModalComponent;
  let fixture: ComponentFixture<CompetitionTeamsModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionTeamsModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionTeamsModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
