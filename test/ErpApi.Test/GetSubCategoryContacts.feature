Feature: GetSubCategoryContacts
	In order to 顯示資料
	As a 線上操作者
	I want to 取得聯絡人資訊
    
Scenario: 以無子站代碼取得聯絡人資訊
    Given 無子站代碼
    When 取得聯絡人資訊
    Then 回傳狀態為 'BadRequest'

Scenario: 以空白子站代碼取得聯絡人資訊
    Given 子站代碼為空白
    When 取得聯絡人資訊
    Then 回傳狀態為 'BadRequest'

Scenario: 以子站代碼 2,3,4,5 取得聯絡人資訊
    Given 子站代碼為 2,3,4,5
    When 取得聯絡人資訊
    Then 回傳成功狀態
    And 回傳第 1 個子站代碼為 2
    And 回傳第 1 個負責PM的BackyardID為 'joannali'
    And 回傳第 1 個負責PM的中文名稱為 '李瑞君'
    And 回傳第 1 個負責PM的分機為 '333'
    And 回傳第 1 個負責PM的Email為 'joannali@yahoo-inc.com'
    And 回傳第 2 個子站代碼為 3
    And 回傳第 2 個PM主管的BackyardID為 'juliachen'
    And 回傳第 2 個PM主管的中文名稱為 '茱莉亞'
    And 回傳第 2 個PM主管的分機為 '123456'
    And 回傳第 2 個PM主管的Email為 'juliachen@yahoo-inc.com'
    And 回傳第 3 個子站代碼為 4
    And 回傳第 3 個採購人員的BackyardID為 'coco0208'
    And 回傳第 3 個採購人員的中文名稱為 '楊雅馨'
    And 回傳第 3 個採購人員的分機為 '770'
    And 回傳第 3 個採購人員的Email為 'coco0208@yahoo-inc.com'
    And 回傳第 4 個子站代碼為 5
    And 回傳第 4 個採購主任的BackyardID為 'cindytu'
    And 回傳第 4 個採購主任的中文名稱為 '杜欣怡'
    And 回傳第 4 個採購主任的分機為 '777'
    And 回傳第 4 個採購主任的Email為 'cindytu@yahoo-inc.com'