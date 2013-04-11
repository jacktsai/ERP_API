Feature: GetCategories
	In order to 顯示資料
	As a 線上使用者
	I want to 取得子站資訊
    
Scenario: 以無子站代碼取得子站資訊
    Given 無子站代碼
    When 取得子站資訊
    Then 回傳狀態為 'BadRequest'

Scenario: 以空白子站代碼取得子站資訊
    Given 子站代碼為空白
    When 取得子站資訊
    Then 回傳狀態為 'BadRequest'
    
Scenario: 以子站代碼 1,2,3,4,5 取得子站資訊
    Given 子站代碼為 1,2,3,4,5
    When 取得子站資訊
    Then 回傳成功狀態
    And 回傳類別 0 的名稱為 '一般區'
    And 回傳類別 1 的名稱為 '品牌區'
    And 回傳類別 0 區碼 3 的名稱為 'NB / PC'
    And 回傳類別 0 區碼 4 的名稱為 '消費電子'
    And 回傳類別 1 區碼 5 的名稱為 '視聽家電'
    And 回傳類別 0 區碼 9 的名稱為 '鞋子、包包'
    And 回傳類別 0 區碼 10 的名稱為 '傢俱/寢飾'
    And 回傳類別 0 區碼 3 子站 1 的名稱為 '筆記型電腦超過十一個字test'
    And 回傳類別 0 區碼 4 子站 2 的名稱為 '數位相機1'
    And 回傳類別 1 區碼 5 子站 3 的名稱為 'AV器材(暫隱形)'
    And 回傳類別 0 區碼 9 子站 4 的名稱為 '流行包'
    And 回傳類別 0 區碼 10 子站 5 的名稱為 '寢具、棉被、床包'