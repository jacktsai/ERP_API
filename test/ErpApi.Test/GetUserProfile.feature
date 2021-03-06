﻿Feature: GetUserProfile
	In order to 顯示線上使用者的資訊
	As a 線上使用者
	I want to 取得使用者的相關資訊

Scenario: 以無 Backyard ID 取得使用者資訊
    Given 無BackyardID
    When 取得使用者資訊
    Then 回傳狀態為 'BadRequest'

Scenario: 以空白 Backyard ID 取得使用者資訊
    Given BackyardID為空白
    When 取得使用者資訊
    Then 回傳狀態為 'BadRequest'

Scenario: 以 Backyard ID 'jacktsai' 取得使用者資訊
    Given BackyardID為 'jacktsai'
	When 取得使用者資訊
    Then 回傳成功狀態
    And 回傳使用者序號為 2733
    And 回傳使用者帳號為 'jacktsai'
    And 回傳使用者姓名為 'Jack Tsai'
    And 回傳使用者部門為 '研發'
    And 回傳使用者等級為 0
    And 回傳使用者首頁為 '/privilege/homepages/erp.asp'
    And 回傳使用者分機為 '3628'
    And 回傳使用者BackyardID為 'jacktsai'
    And 回傳子站代碼為 '25,39'
    
Scenario: 以 Backyard ID 'kevin113' 取得使用者資訊
    Given BackyardID為 'kevin113'
	When 取得使用者資訊
    Then 回傳成功狀態
    And 回傳使用者序號為 2121
    And 回傳使用者帳號為 'kevincheng'
    And 回傳使用者姓名為 '鄭凱文'
    And 回傳使用者部門為 '研發'
    And 回傳使用者等級為 0
    And 回傳使用者首頁為 '/privilege/homepages/ERP.asp'
    And 回傳使用者分機為 '151'
    And 回傳使用者BackyardID為 'kevin113'
    And 回傳子站代碼為 ''
