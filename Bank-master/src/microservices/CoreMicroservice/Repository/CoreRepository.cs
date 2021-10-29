using CoreMicroservice.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreMicroservice.Repository
{
    public class CoreRepository : ICoreRepository
    {
        private readonly IMongoCollection<Account> _colAccount;
        private readonly IMongoCollection<Card> _colCard;
        private readonly IMongoCollection<Transaction> _colTransaction;
        public CoreRepository(IMongoDatabase db)
        {
            _colAccount = db.GetCollection<Account>(Account.DocumentName);
            _colCard = db.GetCollection<Card>(Card.DocumentName);
            _colTransaction = db.GetCollection<Transaction>(Transaction.DocumentName);
        }


        public List<Account> GetAccounts() =>
            _colAccount.Find(FilterDefinition<Account>.Empty).ToList();

        public Account GetAccount(Guid accountId) =>
            _colAccount.Find(c => c.AccountId == accountId).FirstOrDefault();

        public void InsertAccount(Account account) =>
            _colAccount.InsertOne(account);

        public void UpdateAccount(Account account) =>
            _colAccount.UpdateOne(c => c.AccountId == account.AccountId, Builders<Account>.Update
                .Set(c => c.AccountId, account.AccountId)
                .Set(c => c.AccountType, account.AccountType)
                .Set(c => c.CustomerId, account.CustomerId)
                .Set(c => c.CardId, account.CardId)
                .Set(c => c.BranchOffice, account.BranchOffice)
                .Set(c => c.Balance, account.Balance)
                );

        public void DeleteAccount(Guid accountId) =>
            _colAccount.DeleteOne(c => c.AccountId == accountId);

        public List<Card> GetCards() =>
            _colCard.Find(FilterDefinition<Card>.Empty).ToList();

        public Card GetCard(Guid cardid) =>
            _colCard.Find(c => c.CardId == cardid).FirstOrDefault();

        public void InsertCard(Card card) =>
            _colCard.InsertOne(card);

        public void UpdateCard(Card card) =>
            _colCard.UpdateOne(c => c.CardId == card.CardId, Builders<Card>.Update
                .Set(c => c.CardId, card.CardId)
                .Set(c => c.CardType, card.CardType)
                .Set(c => c.IsActive, card.IsActive)
                .Set(c => c.PinCode, card.PinCode)
                );

        public void DeleteCard(Guid cardId) =>
            _colCard.DeleteOne(c => c.CardId == cardId);


        public List<Transaction> GetTransactions() =>
            _colTransaction.Find(FilterDefinition<Transaction>.Empty).ToList();

        public Transaction GetTransaction(Guid transactionId) =>
            _colTransaction.Find(c => c.TransactionId == transactionId).FirstOrDefault();

        public void InsertTransaction(Transaction transaction) =>
            _colTransaction.InsertOne(transaction);

        public void UpdateTransaction(Transaction transaction) =>
            _colTransaction.UpdateOne(c => c.TransactionId == transaction.TransactionId, Builders<Transaction>.Update
                .Set(c => c.TransactionId, transaction.TransactionId)
                .Set(c => c.AccountId, transaction.AccountId)
                .Set(c => c.TransactionType, transaction.TransactionType)
                .Set(c => c.OriginType, transaction.OriginType)
                .Set(c => c.Amount, transaction.Amount)
                );

        public void DeleteTransaction(Guid transactionId) =>
            _colTransaction.DeleteOne(c => c.TransactionId == transactionId);

    }
}
