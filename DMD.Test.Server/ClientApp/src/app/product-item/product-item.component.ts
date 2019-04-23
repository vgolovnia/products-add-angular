import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { Category, Product } from './../types/types';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {

  private categories: Array<Category>;
  private product: Product = { id: 0, name: '', category: null };

  constructor(private route: ActivatedRoute,
    private http: HttpClient,
    private router: Router) { }
    private httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

  ngOnInit() {
    const id = this.route.snapshot.params.id;
    const uriProductTypes = '/api/product/GetTypes';

    this.http.get<Array<Category>>(uriProductTypes, this.httpOptions)
    .subscribe((categories: Array<Category>) => {
        this.categories = categories;
      });
  }

  public add(event) {
    const uriAddProduct = '/api/product/Add';
    this.http.post(uriAddProduct, this.product, this.httpOptions)
    .subscribe((categories: any) => {
      this.router.navigate(['/products/all']);
    });
  }

}
