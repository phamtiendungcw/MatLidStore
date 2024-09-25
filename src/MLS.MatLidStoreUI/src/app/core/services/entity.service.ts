import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  AddressDto,
  ArticleDto,
  CategoryDto,
  CommentDto,
  CreateAddressDto,
  CreateArticleCommand,
  CreateCategoryCommand,
  CreateCommentCommand,
  CreateDiscountDto,
  CreateUserCommand,
  DiscountDto,
  MatLidStoreAPIServices,
  UpdateAddressDto,
  UpdateArticleCommand,
  UpdateCategoryCommand,
  UpdateCommentCommand,
  UpdateDiscountDto,
  UpdateUserCommand,
  UserDto,
} from '../data/mls-data.service';

@Injectable({
  providedIn: 'root',
})
export class EntityService {
  constructor(private apiService: MatLidStoreAPIServices) {}

  // Address CRUD
  getAllAddresses(): Observable<AddressDto[]> {
    return this.apiService.addressAll();
  }
  getAddressById(id: number): Observable<AddressDto> {
    return this.apiService.addressGET(id);
  }
  createAddress(address: CreateAddressDto): Observable<void> {
    return this.apiService.addressPOST(address);
  }
  updateAddress(address: UpdateAddressDto): Observable<void> {
    return this.apiService.addressPUT(address);
  }
  deleteAddress(id: number): Observable<void> {
    return this.apiService.addressDELETE(id);
  }

  // AppUser CRUD
  getAllAppUsers(): Observable<UserDto[]> {
    return this.apiService.userAll();
  }
  getAppUserById(id: number): Observable<UserDto> {
    return this.apiService.userGET(id);
  }
  createAppUser(appUser: CreateUserCommand): Observable<void> {
    return this.apiService.userPOST(appUser);
  }
  updateAppUser(appUser: UpdateUserCommand): Observable<void> {
    return this.apiService.userPUT(appUser);
  }
  deleteAppUser(id: number): Observable<void> {
    return this.apiService.userDELETE(id);
  }

  // Article CRUD
  getAllArticles(): Observable<ArticleDto[]> {
    return this.apiService.articleAll();
  }
  getArticleById(id: number): Observable<ArticleDto> {
    return this.apiService.articleGET(id);
  }
  createArticle(article: CreateArticleCommand): Observable<void> {
    return this.apiService.articlePOST(article);
  }
  updateArticle(article: UpdateArticleCommand): Observable<void> {
    return this.apiService.articlePUT(article);
  }
  deleteArticle(id: number): Observable<void> {
    return this.apiService.articleDELETE(id);
  }

  // Category CRUD
  getAllCategories(): Observable<CategoryDto[]> {
    return this.apiService.categoryAll();
  }
  getCategoryById(id: number): Observable<CategoryDto> {
    return this.apiService.categoryGET(id);
  }
  createCategory(category: CreateCategoryCommand): Observable<void> {
    return this.apiService.categoryPOST(category);
  }
  updateCategory(category: UpdateCategoryCommand): Observable<void> {
    return this.apiService.categoryPUT(category);
  }
  deleteCategory(id: number): Observable<void> {
    return this.apiService.categoryDELETE(id);
  }

  // Comment CRUD
  getAllComments(): Observable<CommentDto[]> {
    return this.apiService.commentAll();
  }
  getCommentById(id: number): Observable<CommentDto> {
    return this.apiService.commentGET(id);
  }
  createComment(comment: CreateCommentCommand): Observable<void> {
    return this.apiService.commentPOST(comment);
  }
  updateComment(comment: UpdateCommentCommand): Observable<void> {
    return this.apiService.commentPUT(comment);
  }
  deleteComment(id: number): Observable<void> {
    return this.apiService.commentDELETE(id);
  }

  // Discount CRUD
  getAllDiscounts(): Observable<DiscountDto[]> {
    return this.apiService.discountAll();
  }
  getDiscountById(id: number): Observable<DiscountDto> {
    return this.apiService.discountGET(id);
  }
  createDiscount(discount: CreateDiscountDto): Observable<void> {
    return this.apiService.discountPOST(discount);
  }
  updateDiscount(discount: UpdateDiscountDto): Observable<void> {
    return this.apiService.discountPUT(discount);
  }
  deleteDiscount(id: number): Observable<void> {
    return this.apiService.discountDELETE(id);
  }

  // Continue with other entities (Order, Payment, Product, etc.) similarly...
}
