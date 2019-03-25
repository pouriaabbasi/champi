import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionLeagueMatchConfigModalComponent } from './competition-league-match-config-modal.component';

describe('CompetitionLeagueMatchConfigModalComponent', () => {
  let component: CompetitionLeagueMatchConfigModalComponent;
  let fixture: ComponentFixture<CompetitionLeagueMatchConfigModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionLeagueMatchConfigModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionLeagueMatchConfigModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
