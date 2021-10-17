import { FastCourseTemplatePage } from './app.po';

describe('FastCourse App', function() {
  let page: FastCourseTemplatePage;

  beforeEach(() => {
    page = new FastCourseTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
