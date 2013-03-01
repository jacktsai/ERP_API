Feature: GetAuthority
	In order to 權限控管
	As a 線上操作者
	I want to 確認使用者權限
    
Scenario: 以無 Backyard ID 取得操作權限
    Given 無BackyardID
    And 無目標網址
    When 取得操作權限
    Then 回傳狀態為 'BadRequest'
    
Scenario: 以空白 Backyard ID 取得操作權限
    Given BackyardID為空白
    And 目標網址為空白
    When 取得操作權限
    Then 回傳狀態為 'BadRequest'

Scenario: 以 Backyard ID 'jacktsai' 取得 '/privileges/default.aspx' 的操作權限
    Given BackyardID為 'jacktsai'
    And 目標網址為 '/privileges/default.aspx'
	When 取得操作權限
	Then 回傳操作者BardyardID為 'jacktsai'
    And 回傳目標網址為 '/privileges/default.aspx'
    And 回傳細部權限-SELECT為 False
    And 回傳細部權限-INSERT為 True
    And 回傳細部權限-UPDATE為 False
    And 回傳細部權限-DELETE為 True
    And 回傳細部權限-特殊權限為 False
