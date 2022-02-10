import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'market-contributions',
  templateUrl: './market-contributions.component.html'
})
export class MarketContributionsComponent {
  public contribs$: Observable<MarketContribution[]>;

  // Define default values
  public instrumentId = 'EUR/USD';
  public price = 100;
  public size = 1;
  public side = 'Bid';
  public errorMessage = '';

  private baseMarketContributionApiUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.baseMarketContributionApiUrl = this.baseUrl + 'api/marketcontributions/';
    this.contribs$ = this.getContributions();
  }

  public submitMarketData() {
    const marketDataQuote = {
      instrumentId: this.instrumentId,
      price: this.price,
      size: this.size,
      side: this.side
    } as MarketData;
    this.http.post<string>(this.baseMarketContributionApiUrl + 'fxquotes', marketDataQuote).subscribe(
      result => {
        this.errorMessage = '';
        this.contribs$ = this.getContributions()
      },
      error => this.errorMessage = JSON.stringify(error)
    );
  }

  private getContributions() {
    return this.http.get<MarketContribution[]>(this.baseMarketContributionApiUrl)
      .pipe(
        map(contribs => contribs
          .map(contrib => ({ ...contrib, date: new Date(contrib.date) }))
          .sort((a, b) => b.date.getTime() - a.date.getTime())
        )
    );
  }
}

interface MarketContribution {
  id: number;
  date: Date;
  marketDataType: string;
  userId: number;
  marketData: MarketData;
  regulationFramework: string;
}

interface MarketData {
  instrumentId: string;
  price: number;
  size: number;
  side: string;
}
