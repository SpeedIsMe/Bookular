import { TestBed } from '@angular/core/testing';

import { BookularService } from './bookular.service';
import { HttpClient } from '@angular/common/http';
import { IBook } from '../app/home/IBook';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('BookularService', () => {
  let service: BookularService;

  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;

  const expectedBooks: IBook[] =
    [{
      id: 1,
      title: "test boek",
      description: "test boeken beschrijving",
      author: {
        id: 1,
        firstName: "Kees",
        lastName: "Test",
        bio: "Kees Test is een bijzondere auteur",
        books: null
      },
      authorId: 1
    },
    {
      id: 2,
      title: "test boek",
      description: "test boeken beschrijving",
      author: {
        id: 2,
        firstName: "Kees",
        lastName: "Test",
        bio: "Kees Test is een bijzondere auteur",
        books: null
      },
      authorId: 2
    }];

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });

    httpClient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);

    service = TestBed.inject(BookularService);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('can test HttpClient.get', () => {
    const testUrl = '/data';

    httpClient.get<IBook[]>(testUrl)
      .subscribe(data =>
        expect(data).toEqual(expectedBooks)
      );

    const req = httpTestingController.expectOne('/data');

    expect(req.request.method).toEqual('GET');

    req.flush(expectedBooks);

    httpTestingController.verify();
  });

  it('should call getBooks with method get and return expected books', () => {
    service.getBooks("test").subscribe((res: any) => {
      expect(res).toEqual(expectedBooks);
    });

    const req = httpTestingController.expectOne({
      method: 'GET',
      url: `https://localhost:7195/api/book/find/test`,
    });

    expect(req.request.url.endsWith("/test")).toEqual(true);

    req.flush(expectedBooks);
  });

  it('should call addBook with method post and return an added book', () => {

    service.addBook(expectedBooks[0]).subscribe((res) => {
      expect(res).toEqual(expectedBooks[0]);
    });

    const req = httpTestingController.expectOne({
      method: 'POST',
      url: `https://localhost:7195/api/book/add`,
    });

    req.flush(expectedBooks[0]);
  });
});

