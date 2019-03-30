import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompetitionLeagueResultComponent } from './competition-league-result.component';

describe('CompetitionLeagueResultComponent', () => {
  let component: CompetitionLeagueResultComponent;
  let fixture: ComponentFixture<CompetitionLeagueResultComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompetitionLeagueResultComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompetitionLeagueResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
