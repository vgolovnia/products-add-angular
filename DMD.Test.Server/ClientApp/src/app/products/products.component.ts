import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { Category, Product } from './../types/types';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  private type: string;
  private categories: Array<Category>;
  private assets: Array<Product>;

  constructor(private route: ActivatedRoute,
    private http: HttpClient,
    private router: Router) { }
    private httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

  ngOnInit() {
    this.type = this.route.snapshot.params.type;
    this.reloadAssets();

    const uriAssetTypes = '/api/product/GetTypes';

    this.http.get<Array<Category>>(uriAssetTypes, this.httpOptions)
    .subscribe((categories: Array<Category>) => {
        this.categories = categories;
      });

    this.router.events
    .subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.reloadAssets();
    }});
  }

  reloadAssets() {
    const uriAsset = '/api/product/Get/' + this.route.snapshot.params.type;
    this.http.get<Array<Product>>(uriAsset, this.httpOptions)
    .subscribe((dataAssets: Array<Product>) => {
          this.assets = dataAssets;
      });
  }

}

