Feature: GetProfile
	In order to 顯示線上操作者的資訊
	As a 線上操作者
	I want to 取得操作者的資訊

Scenario: 以無 Backyard ID 取得登入資訊
    Given 無BackyardID
    When 取得操作者資訊
    Then 回傳狀態為 'BadRequest'

Scenario: 以空白 Backyard ID 取得登入資訊
    Given BackyardID為空白
    When 取得操作者資訊
    Then 回傳狀態為 'BadRequest'

Scenario: 以 Backyard ID 'jacktsai' 取得登入資訊
    Given BackyardID為 'jacktsai'
	When 取得操作者資訊
    Then 回傳成功狀態
    And 回傳操作者序號為 2733
    And 回傳操作帳號為 'jacktsai'
    And 回傳操作者中文姓名為 'Jack Tsai'
    And 回傳操作者部門為 '研發'
    And 回傳操作者等級為 0
    And 回傳操作者首頁為 '/privilege/homepages/erp.asp'
    And 回傳操作者分機為 '3628'
    And 回傳操作者BackyardID為 'jacktsai'
    And 回傳操作者的子站為 '25,39'
    
Scenario: 以 Backyard ID 'kevin113' 取得登入資訊
    Given BackyardID為 'kevin113'
	When 取得操作者資訊
    Then 回傳成功狀態
    And 回傳操作者序號為 2121
    And 回傳操作帳號為 'kevincheng'
    And 回傳操作者中文姓名為 '鄭凱文'
    And 回傳操作者部門為 '研發'
    And 回傳操作者等級為 0
    And 回傳操作者首頁為 '/privilege/homepages/ERP.asp'
    And 回傳操作者分機為 '151'
    And 回傳操作者BackyardID為 'kevin113'
    And 回傳操作者的子站為 ''
